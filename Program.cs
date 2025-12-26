using WepApi.DBOperations;

namespace WepApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // in memory de baslang�c olarak database kontrolu ve veri ekleme i�in kullan�l�yor
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Initialize(services);
            }
            host.Run();


            //CreateHostBuilder(args).Build().Run(); // inmemory olmadan
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
