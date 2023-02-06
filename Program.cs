using Contractv2.Services;
using Contractv2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jS35Xd0xiW3xdcHZVRA==;Mgo+DSMBPh8sVXJ0S0J+XE9AflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdEVnWHZfcndWRmNaUw==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjXX5XcXZWRWBZUEM=;MTA2NjM2NUAzMjMwMmUzNDJlMzBOb2RwVmZoS0pLL3Fxc1htRXZYdTA5c21sMkdKQlV4WFZtb0duSkF2dU9vPQ==;MTA2NjM2NkAzMjMwMmUzNDJlMzBYYlZKM0R1Yjc3aTFrd256bXkwMlBrM3h1YWIvM0pJNWhLWlhDOXk1RU5BPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVhWXtfeXVXRWNdU0N0;MTA2NjM2OEAzMjMwMmUzNDJlMzBHYUdka1Y2Z0dLV2tHOVNEWXd0eVpiSzJ5UnROdjN6cHJRQmlIZVVENWgwPQ==;MTA2NjM2OUAzMjMwMmUzNDJlMzBYZ2RaZEM5aHRkSjFxME5XM0FEUkV6ZDlXOUtZN1ltcTVzOXNHVGxZbDM4PQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjXX5XcXZWRWJcUEY=;MTA2NjM3MUAzMjMwMmUzNDJlMzBpa2EwSXVLZ2R1aTlRUjFJOXAxYXI4Qm01LzVKd2FheHQ3WWsxZnBCd25RPQ==;MTA2NjM3MkAzMjMwMmUzNDJlMzBLeERNRjhoWjk4bGZQUU1GcGlRUlFhWHZGL0pKYTZSdFpiRXFObDRtN1ZJPQ==;MTA2NjM3M0AzMjMwMmUzNDJlMzBHYUdka1Y2Z0dLV2tHOVNEWXd0eVpiSzJ5UnROdjN6cHJRQmlIZVVENWgwPQ==");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var _url = "https://owggnknxreffmtdthixu.supabase.co";
var _key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93Z2dua254cmVmZm10ZHRoaXh1Iiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY3NTQ2NjcwMCwiZXhwIjoxOTkxMDQyNzAwfQ.4eJ97Jv-wDgCjEBY-66y0kQYateba3XRRTnWmNXOeoA";
var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};
builder.Services.AddScoped<Supabase.Client>(provider => new Supabase.Client(_url, _key, options));
builder.Services.AddTransient<FileConverterService>();
builder.Services.AddSingleton<ChangelogService>();

builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
