using RestWithAspNet5Example.Data.DTO;

namespace RestWithAspNet5Example.Business.Implemantations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetByte(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDetailDTO> SaveFileToDisk(IFormFile file)
        {
            FileDetailDTO fileDetail = new FileDetailDTO();

            if (file == null || file.Length < 0) return fileDetail;

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower().Equals(".pdf") || fileType.ToLower().Equals(".jpg")
                 || fileType.ToLower().Equals(".png") || fileType.ToLower().Equals(".jpeg"))
            {
                var docName = Path.GetFileName(file.FileName.Replace(" ", "_"));
                var destination = Path.Combine(_basePath, "", docName);
                fileDetail.DocName = docName;
                fileDetail.DocType = fileType;
                fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + docName);

                using (var stream = new FileStream(destination, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return fileDetail;
        }

        public async Task<List<FileDetailDTO>> SaveFilesToDisk(List<IFormFile> files)
        {
            List<FileDetailDTO> filesDetail = new List<FileDetailDTO>();

            foreach (var file in files)
            {
                filesDetail.Add(await SaveFileToDisk(file));
            }
            return filesDetail;
        }
    }
}
