using CommonBase.Data.Interfaces;
using CommonBase.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CommonBase.Data
{
  public static class DIRegisterMongo
  {
    public static void RegisterNestServices(this IServiceCollection services)
    {
      services.AddTransient<INationService, NationService>();
      //services.AddTransient<ISaveSetUpData, SaveSetUpData>();
      //services.AddTransient<ICountyService, CountyService>();
      //services.AddTransient<IGenderService, GenderService>();
      //services.AddTransient<IIdTypeService, IdTypeService>();
      //services.AddTransient<IMakeService, MakeService>();
      //services.AddTransient<IMaritalService, MaritalService>();
      //services.AddTransient<INestAccountService, NestAccountService>();
      //services.AddTransient<INestBankService, NestBankService>();
      
      //services.AddTransient<ISuffixService, SuffixService>();
      //services.AddTransient<ISystemParamService, SystemParamService>();
      //services.AddTransient<ICurrencyService, CurrencyService>();
    }
  }
}
