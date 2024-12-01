using System;
using System.Threading.Tasks;
using Volo.Abp.Content;

namespace OneGen.Storage
{
	public interface IStorageAppService
	{
		Task<IRemoteStreamContent> GetFileAsync(Guid id);
	}
}