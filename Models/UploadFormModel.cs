namespace WebWinMVC.Models
{
    public class UploadFormModel
    {
        public string ?UploadType { get; set; } // 用于区分上传类型
        public string ?UploadLabel { get; set; } // 显示的标签
        public int MaxFileSizeMB { get; set; } // 最大文件大小（MB）
    }

}
