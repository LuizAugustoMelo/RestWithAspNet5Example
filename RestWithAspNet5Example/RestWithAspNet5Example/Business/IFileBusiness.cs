using RestWithAspNet5Example.Data.DTO;

namespace RestWithAspNet5Example.Business
{
    public interface IFileBusiness
    {
        byte[] GetByte(string fileName);
        Task<FileDetailDTO> SaveFileToDisk(IFormFile file);
        Task<List<FileDetailDTO>> SaveFilesToDisk(List<IFormFile> files);
    }
}
