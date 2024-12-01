using OneGen.Storage;
using System;
using System.Threading.Tasks;
using Volo.Abp.Content;

namespace OneGen.Variants
{
	public class StorageAppService(StorageManager storageManager)
		: OneGenAppService,
		IStorageAppService
	{
		public Task<IRemoteStreamContent> GetFileAsync(Guid id)
		{
			return storageManager.GetFileAsync(id);
		}
	}
}