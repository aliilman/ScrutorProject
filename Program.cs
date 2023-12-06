
using Scrutor;
using ScrutorProject.UserService;
using ScrutorProject.UserServicve;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped< IRepository<User>, UserRepository>();



//**** NameSpace İle Tanımlama**//

// builder.Services.Scan(selector => selector 
//     .FromCallingAssembly()
//     .AddClasses(
//         classSelector =>
//             classSelector.InNamespaces("ScturorProject.UserService.IRepository")
//     )
//     .AsImplementedInterfaces()
// );


//Decoator Desing Patten Kullanımı
builder.Services.AddScoped< IRepository<User>, UserRepository>();
builder.Services.Decorate<IRepository<User>, RepositoryLoggerDecorator<User>>();

//Scan kullanımı
builder.Services.Scan(selector => selector
    .FromCallingAssembly()
    .AddClasses(false) // filtreleme yapılabilir - publicOnly: false
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)// hizmet zaten mevcutsa kayıtları atlar
    .AsMatchingInterface()//Classname => IClassName şeklinde eşleşen sınfıları ekler
    .WithScopedLifetime() 

);

//.UsingRegistrationStrategy(RegistrationStrategy.Append)// mevcut hizmetler için yeni bir kayıt ekler
//.UsingRegistrationStrategy(RegistrationStrategy.Throw)// mevcut bir hizmeti kaydetmeye çalışırken atar

//.WithTransientLifetime()
//.WithSingletonLifetime()


// // Farklı Tanımalar

// builder.Services.Scan(selector => selector
//     .FromAssemblyOf<IUserService>()
//     .AddClasses(classSelector => classSelector.AssignableTo<IUserService>())
//     .AsMatchingInterface()//Classname => IClassName
//     .UsingRegistrationStrategy(RegistrationStrategy.Skip)

//     );

//Inteface e sahip olmayan sınıflar için
// services.Scan(scan => scan
//   .FromAssemblyOf<IService>()
//     .AddClasses()
//       .AsSelf() 
//       .WithSingletonLifetime());
//              =
//services.AddSingleton<TestService>();

// // Generic Sınıflar İler Çalışma

// builder.Services.Scan(selector => selector
//     .FromCallingAssembly()
//     .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
//     .AsImplementedInterfaces()
//     .WithScopedLifetime()// Bağımlılıkların ömrünü belirleme
//     );



//Tek Seferde Birden Fazla Servis Tanımlama
// builder.Services.Scan(selector => selector
//     .FromAssemblyOf<IUserService>()
//     .AddClasses(classSelector =>classSelector.AssignableTo<IUserService>())
//     .AsMatchingInterface()
//     .UsingRegistrationStrategy(RegistrationStrategy.Skip)// Gözden Geçir
//     .FromCallingAssembly()
//     .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
//     .AsImplementedInterfaces()
//     .WithScopedLifetime()// Bağımlılıkların ömrünü belirleme
//     );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//https://andrewlock.net/using-scrutor-to-automatically-register-your-services-with-the-asp-net-core-di-container/