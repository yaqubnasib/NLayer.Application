using Microsoft.IO;

namespace NLayer.API.MiddleWares
{
    public class HttpLoggerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpLoggerMiddleWare> _logger;
        private readonly RecyclableMemoryStreamManager _recylabeleMemeorystream;

        public HttpLoggerMiddleWare(RequestDelegate handler, ILogger<HttpLoggerMiddleWare> logger)
        {
            this._next = handler;
            this._logger = logger;
            this._recylabeleMemeorystream = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context)
        {

        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();

            using (var requestStream = _recylabeleMemeorystream.GetStream())
            {
                await context.Request.Body.CopyToAsync(requestStream);

                string requestBody = ReadStreamInChunks(requestStream);

                _logger.LogInformation("request recived. {Requesturl} {RequestBody} {QueryString}",
                    context.Request.Path,requestBody,context.Request.QueryString);

                context.Request.Body.Position = 0;  
            }

        }

        public async Task LogResponse(HttpContext context)
        {



        }

        public static string ReadStreamInChunks(Stream stream)
        {
            int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using (var writer = new StringWriter())
            {
                using (var reader = new StreamReader(stream))
                {
                    var readChunk = new char[readChunkBufferLength];
                    int readChunkLength;

                    do
                    {
                        readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                        writer.Write(readChunk, 0, readChunkLength);

                    } while (readChunkLength > 0);

                    return writer.ToString();
                }
            }

        }
    }
}
