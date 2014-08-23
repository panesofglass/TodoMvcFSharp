namespace TodoMvcFSharp

open Owin
open Microsoft.Owin
open System.Net.Http
open System.Web.Http

type Startup() =

    static member RegisterWebApi(config: HttpConfiguration) =
        // Configure serialization
        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

    member __.Configuration(app: IAppBuilder) =
        app .UseCors(Cors.CorsOptions.AllowAll)
            |> ignore

[<assembly: OwinStartupAttribute(typeof<Startup>)>]
do ()