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

        public UploadController(
            IImageProcessorService imgProcessorService,
            IFileSaverService fileSaverService,
            IRegularUserService userService,
            IProjectService projectService)
        {
            Guard.WhenArgument(imgProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();
            Guard.WhenArgument(userService, "regularUserService").IsNull().Throw();
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();

            this.fileSaverService = fileSaverService;
            this.imageProcessorService = imgProcessorService;
            this.regularUserService = userService;
            this.projectService = projectService;
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Image(HttpPostedFileBase image, string name, Guid? projectId = null)
        {
            if (image != null)
            {
                var fileSize = image.ContentLength;
                var fileExtension = Path.GetExtension(image.FileName).ToLower();
                string fileName = null;
                if (name == Business.Common.Constants.AvatarFileNameWithoutExtension)
                {
                    fileName = Business.Common.Constants.AvatarFileNameWithoutExtension + fileExtension;
                }
                else
                {
                    fileName = Business.Common.Constants.ProjectMainImageFileNameWithoutExtension + fileExtension;
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
                            Business.Common.Constants.ProfileAvatarImageSize,
                            Business.Common.Constants.ProfileAvatarImageSize,
                            fileExtension,
                            Business.Common.Constants.MaxImageQualityPercentage);

                        // saving image
                        string dirToSaveIn = null;
                        if (name == Business.Common.Constants.AvatarFileNameWithoutExtension)
                        {
                            dirToSaveIn = Path.Combine(
                                Server.MapPath("~" + Business.Common.Constants.ContentUploadedProfilesRelPath),
                                this.User.Identity.GetUserId());
                        }
                        else
                        {
                            dirToSaveIn = Path.Combine(
                                Server.MapPath("~" + Business.Common.Constants.ContentUploadedProjectsRelPath),
                                projectId.ToString());
                        }

                        this.fileSaverService.SaveFile(processedImg, dirToSaveIn, fileName, true);
                    }
                    catch (Exception)
                    {
                        return Content("We are sorry, but the uploading of your image was unsuccessful.");
                    }

                    // saving uploaded image's url to db
                    if (name == Business.Common.Constants.AvatarFileNameWithoutExtension)
                    {
                        var uploaderId = this.User.Identity.GetUserId();
                        var avatarUrl = Business.Common.Constants.ContentUploadedProfilesRelPath + uploaderId + "/" + fileName;
                        this.regularUserService.UpdateAvatarUrl(uploaderId, avatarUrl);

                        // change img src in navbar
                        this.HttpContext.Cache["AvatarUrl"] = avatarUrl;
                    }
                    else
                    {
                        var imageUrl = Business.Common.Constants.ContentUploadedProjectsRelPath + projectId.ToString() + "/" + fileName;
                        this.projectService.UpdateImageUrl((Guid)projectId, imageUrl);
                    }

                    // Empty string signifies success
                    return Content("");
                }
            }

            return Content("We are sorry, but the uploading of your image was unsuccessful.");
        }
    }
}