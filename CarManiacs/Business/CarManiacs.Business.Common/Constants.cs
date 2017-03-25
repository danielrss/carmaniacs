namespace CarManiacs.Business.Common
{
    public class Constants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 30;
        
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 50;

        public const int UrlMinLength = 10;
        public const int UrlMaxLength = 2048;

        public const int ProjectDescriptionMinLength = 5;
        public const int ProjectDescriptionMaxLength = 1000;

        public const int MinAge = 13;
        public const int MaxAge = 100;

        public const int MinAddressLength = 4;
        public const int MaxAddressLength = 30;

        public const int MinCommentLength = 5;
        public const int MaxCommentLength = 500;

        public const int UploadFileMaxSizeInBytes = 5 * 1024 * 1024;

        public const int ProfileAvatarImageSize = 200;

        public const int ThumbnailImageSize = 500;
        public const int LargeImageSize = 700;

        public const int ThumbnailImageQualityPercentage = 80;
        public const int MaxImageQualityPercentage = 100;

        public const string FailedUploadMessage = "Unfortunately, your uploading  has failed.\r\nPlease, try again later.";

        public const string AvatarFileNameWithoutExtension = "avatar";
        public const string DefaultAvatarUrl = "/Content/Images/avatar.png";
        //public const string ContentUploadedTakeABreakThumbnailsRelPath = "Content/Uploaded/TakeABreak/Thumbnails/";
        //public const string ContentUploadedTakeABreakOriginalsRelPath = "Content/Uploaded/TakeABreak/Originals/";

        public const string ContentUploadedProfilesRelPath = "/Content/Uploaded/Profiles/";
    }
}
