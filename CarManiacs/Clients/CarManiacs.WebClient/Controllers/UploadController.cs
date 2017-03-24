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

        public UploadController(
            IImageProcessorService imgProcessorService,
            IFileSaverService fileSaverService,
            IRegularUserService userService)
        {
            Guard.WhenArgument(imgProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();
            Guard.WhenArgument(userService, "regularUserService").IsNull().Throw();

            this.fileSaverService = fileSaverService;
            this.imageProcessorService = imgProcessorService;
            this.regularUserService = userService;
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Avatar(HttpPostedFileBase avatar)
        {
            if (avatar != null)
            {
                var fileSize = avatar.ContentLength;
                var fileExtension = Path.GetExtension(avatar.FileName).ToLower();
                var fileName = Business.Common.Constants.AvatarFileNameWithoutExtension + fileExtension;

                bool isFileValid = (fileSize <= Business.Common.Constants.UploadFileMaxSizeInBytes) &&
                    ((avatar.ContentType == "image/jpeg" && (fileExtension == ".jpg" || fileExtension == ".jpeg")) ||
                    (avatar.ContentType == "image/png" && fileExtension == ".png"));
                if (isFileValid)
                {
                    byte[] photoBytes = new byte[fileSize];
                    avatar.InputStream.Read(photoBytes, 0, fileSize);
                    string uploaderId = null;

                    try
                    {
                        // processing image
                        var processedImg = this.imageProcessorService.ProcessImage(
                            photoBytes,
                            Business.Common.Constants.ProfileAvatarImageSize,
                            Business.Common.Constants.ProfileAvatarImageSize,
                            fileExtension,
                            Business.Common.Constants.MaxImageQualityPercentage);
                        uploaderId = this.User.Identity.GetUserId();

                        // saving image
                        var dirToSaveIn = Path.Combine(
                            Server.MapPath("~" + Business.Common.Constants.ContentUploadedProfilesRelPath),
                            uploaderId);

                        this.fileSaverService.SaveFile(processedImg, dirToSaveIn, fileName, true);
                    }
                    catch (Exception)
                    {
                        return Content("We are sorry, but the uploading of your image was unsuccessful.");
                    }
                    

                    // saving uploaded avatar's url to db
                    var avatarUrl = Business.Common.Constants.ContentUploadedProfilesRelPath + uploaderId + "/" + fileName;
                    this.regularUserService.UpdateAvatarUrl(uploaderId, avatarUrl);

                    // change img src in navbar
                    this.HttpContext.Cache["AvatarUrl"] = avatarUrl;

                    // Empty string signifies success
                    return Content("");
                }
            }

            return Content("We are sorry, but the uploading of your image was unsuccessful.");
        }
    }
}