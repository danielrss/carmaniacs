using Bytes2you.Validation;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.ActionFilters;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class UploadController : Controller
    {
        private IImageProcessorService imageProcessorService;
        private IFileSaverService fileSaverService;
        private IRegularUserService regularUserService;
        private IProjectService projectService;
        private IStoryService storyService;

        public UploadController(
            IImageProcessorService imgProcessorService,
            IFileSaverService fileSaverService,
            IRegularUserService userService,
            IProjectService projectService,
            IStoryService storyService)
        {
            Guard.WhenArgument(imgProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();
            Guard.WhenArgument(userService, "regularUserService").IsNull().Throw();
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();
            Guard.WhenArgument(storyService, "storyService").IsNull().Throw();

            this.fileSaverService = fileSaverService;
            this.imageProcessorService = imgProcessorService;
            this.regularUserService = userService;
            this.projectService = projectService;
            this.storyService = storyService;
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Image(HttpPostedFileBase image, string uploadFor, Guid? id = null)
        {
            if (image != null)
            {
                var fileSize = image.ContentLength;
                var fileExtension = Path.GetExtension(image.FileName).ToLower();
                string fileName = null;
                if (uploadFor == Business.Common.Constants.UploadForProfileAvatarName)
                {
                    fileName = Business.Common.Constants.AvatarFileNameWithoutExtension + fileExtension;
                }
                else if(uploadFor == Business.Common.Constants.UploadForProjectName ||
                    uploadFor == Business.Common.Constants.UploadForStoryName)
                {
                    fileName = Business.Common.Constants.MainImageFileNameWithoutExtension + fileExtension;
                }

                bool isFileValid = (fileSize <= Business.Common.Constants.UploadFileMaxSizeInBytes) &&
                    ((image.ContentType == "image/jpeg" && (fileExtension == ".jpg" || fileExtension == ".jpeg")) ||
                    (image.ContentType == "image/png" && fileExtension == ".png"));
                if (isFileValid)
                {
                    byte[] photoBytes = new byte[fileSize];
                    image.InputStream.Read(photoBytes, 0, fileSize);

                    try
                    {
                        // processing image
                        var processedImg = this.imageProcessorService.ProcessImage(
                            photoBytes,
                            Business.Common.Constants.ThumbnailImageSize,
                            Business.Common.Constants.ThumbnailImageSize,
                            fileExtension,
                            Business.Common.Constants.MaxImageQualityPercentage);

                        // saving image
                        string dirToSaveIn = null;
                        if (uploadFor == Business.Common.Constants.UploadForProfileAvatarName)
                        {
                            dirToSaveIn = Path.Combine(
                                Server.MapPath("~" + Business.Common.Constants.ContentUploadedProfilesRelPath),
                                this.User.Identity.GetUserId());
                        }
                        else if (uploadFor == Business.Common.Constants.UploadForProjectName)
                        {
                            dirToSaveIn = Path.Combine(
                                Server.MapPath("~" + Business.Common.Constants.ContentUploadedProjectsRelPath),
                                id.ToString());
                        }
                        else if (uploadFor == Business.Common.Constants.UploadForStoryName)
                        {
                            dirToSaveIn = Path.Combine(
                                Server.MapPath("~" + Business.Common.Constants.ContentUploadedStoriesRelPath),
                                id.ToString());
                        }

                        this.fileSaverService.SaveFile(processedImg, dirToSaveIn, fileName, true);
                    }
                    catch (Exception)
                    {
                        return Content("We are sorry, but the uploading of your image was unsuccessful.");
                    }

                    // saving uploaded image's url to db
                    if (uploadFor == Business.Common.Constants.UploadForProfileAvatarName)
                    {
                        var uploaderId = this.User.Identity.GetUserId();
                        var avatarUrl = Business.Common.Constants.ContentUploadedProfilesRelPath + uploaderId + "/" + fileName;
                        this.regularUserService.UpdateAvatarUrl(uploaderId, avatarUrl);

                        // change img src in navbar
                        this.HttpContext.Session["AvatarUrl"] = avatarUrl;
                    }
                    else if (uploadFor == Business.Common.Constants.UploadForProjectName)
                    {
                        var imageUrl = Business.Common.Constants.ContentUploadedProjectsRelPath + id.ToString() + "/" + fileName;
                        this.projectService.UpdateImageUrl((Guid)id, imageUrl);
                    }
                    else if (uploadFor == Business.Common.Constants.UploadForStoryName)
                    {
                        var imageUrl = Business.Common.Constants.ContentUploadedStoriesRelPath + id.ToString() + "/" + fileName;
                        this.storyService.UpdateMainImageUrl((Guid)id, imageUrl);
                    }

                    // Empty string signifies success
                    return Content("");
                }
            }

            return Content("We are sorry, but the uploading of your image was unsuccessful.");
        }
    }
}