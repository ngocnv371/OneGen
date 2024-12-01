using OneGen.Settings;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Content;
using Volo.Abp.Domain.Services;
using Volo.Abp.Imaging;
using Volo.Abp.Settings;

namespace OneGen.Storage
{
	public class ImagingService(ISettingProvider setting, IImageResizer resizer, IImageCompressor compressor) : DomainService
	{
		/// <summary>
		/// Resize to configured max width/height (scale down only), then compress the image.
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public async Task<Stream> NormalizeImage(IRemoteStreamContent file)
		{
			var stream = file.GetStream();
			if (OneGenConsts.SupportedImageTypes.Contains(file.ContentType))
			{
				var maxWidth = await setting.GetAsync<int>(OneGenSettings.Imaging.MaxWidth);
				var maxHeight = await setting.GetAsync<int>(OneGenSettings.Imaging.MaxHeight);
				// scale down only
				var mode = ImageResizeMode.Min;

				var args = new ImageResizeArgs(maxWidth, maxHeight, mode);
				var resized = await resizer.ResizeAsync(
					stream, args
					);
				if (resized.State != ImageProcessState.Done)
				{
					return stream;
				}

				stream = resized.Result;
				var compressed = await compressor.CompressAsync(stream, file.ContentType);
				if (compressed.State != ImageProcessState.Done)
				{
					return compressed.Result;
				}
			}

			return stream;
		}
	}
}