using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoADIS;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration);

startup.ConfigureServices(builder.Services);


DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
cloudinary.Api.Secure = true;

var getResourceParams = new GetResourceParams("cld-sample")
{
    QualityAnalysis = true
};
var getResourceResult = cloudinary.GetResource(getResourceParams);
var resultJson = getResourceResult.JsonObj;

// Log quality analysis score to the console
Console.WriteLine(resultJson["quality_analysis"]);

// Transform the uploaded asset and generate a URL and image tag
//==============================

var myTransformation = cloudinary.Api.UrlImgUp.Transform(new Transformation()
    .Width(300).Crop("scale").Chain()
    .Effect("cartoonify"));

var myUrl = myTransformation.BuildUrl("cld-sample");
var myImageTag = myTransformation.BuildImageTag("cld-sample");

// Log the URL of the transformed asset to the console
Console.WriteLine(myUrl);

// Log the image tag for the transformed asset to the console
Console.WriteLine(myImageTag);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
