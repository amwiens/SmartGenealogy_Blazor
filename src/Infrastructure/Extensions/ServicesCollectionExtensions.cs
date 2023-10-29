using SmartGenealogy.Application.Services.PaddleOCR;
using SmartGenealogy.Infrastructure.Services.PaddleOCR;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ExceptionHandlingMiddleware>()
            .AddScoped<IDateTime, DateTimeService>()
            .AddScoped<IExcelService, ExcelService>()
            .AddScoped<IUploadService, UploadService>()
            .AddTransient<IDocumentOcrJob, DocumentOcrJob>()
            .AddScoped<IPDFService, PDFService>();
    }
}