open System.Net
open System.IO
open System.Text
open System.Web
open System.Text.RegularExpressions
open System.Collections.Generic
open System.Xml
open log4net

let matching_text = @"<div class=""textbody"" id=""storyText"" >([\W\w]*)</div>

	<script"

let log:ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

let showLog (content:string) = 
    System.Console.Write(content + "\n")
    log.Debug(content)

let resumeList = new Dictionary<string, List<string>>();

let getuser (u:string) = 
    if not(Directory.Exists(u)) then
        Directory.CreateDirectory(u) |> ignore

    let novel:List<string> = new List<string>()
    let link:List<string> = new List<string>()
    
    let host = "http://www.wattpad.com/"

    showLog(System.String.Format("User: {0} ", u))

    let req:HttpWebRequest = WebRequest.Create(host + "user/" + u + "?uploads&page=0") :?> HttpWebRequest;
    req.Method <- "GET"

    let resp = new StreamReader(req.GetResponse().GetResponseStream())
    let respstr = resp.ReadToEnd();

    let matches = Regex.Matches(respstr, @"<a class=""paging"" href=""[^\>\<]*"">(\d+)</a>")

    let maxUserUploadPage = 
        match (matches.Count > 0) with
        | true ->  matches.Item(matches.Count - 1).Groups.[1].Value |> int
        | false -> 1

    showLog(System.String.Format("Max User Upload page: {0} Starting to get novel's list....",maxUserUploadPage))

    for i in 0 .. maxUserUploadPage - 1 do
        let req:HttpWebRequest = WebRequest.Create(host + "user/" + u + "?uploads&page=" + i.ToString()) :?> HttpWebRequest;
        req.Method <- "GET"

        let resp = new StreamReader(req.GetResponse().GetResponseStream())
        let respstr = resp.ReadToEnd();

        let matches = Regex.Matches(respstr, @"<h1 style=""margin-bottom:2px""><a href=""([^\<\>]*)"" class=""title"">([^\<\>]*)</a></h1>")
        
        for j in 0 .. (matches.Count - 1) do
            link.Add(matches.Item(j).Groups.Item(1).Value)
            novel.Add(matches.Item(j).Groups.Item(2).Value)

        showLog(System.String.Format("\tGet novel list of page: {0} - NON: {1}",(i+1),matches.Count))

    showLog(System.String.Format("Number of Novels: {0}",link.Count))

    let mutable novelNumber = -1
    let mutable novelPage = -1

    if (resumeList.ContainsKey(u)) then
        novelNumber <- resumeList.[u].[0] |> int
        novelPage <- resumeList.[u].[1] |> int
    
    for i in (match (novelNumber <> -1) with | true -> novelNumber | false -> 0) .. (novel.Count - 1) do
        let currentlink = link.[i]
        let currentnovel = novel.[i]

        showLog(System.String.Format("\tNovel ({0}): {1}  ", i, currentnovel))

        let req:HttpWebRequest = WebRequest.Create(host + currentlink) :?> HttpWebRequest;
        req.Method <- "GET"

        let a:List<string> = new List<string>()

        let resp = new StreamReader(req.GetResponse().GetResponseStream())
        let respstr = resp.ReadToEnd()

        let matches = Regex.Matches(respstr, @"> / (\d+) <")
        let mutable max_page = 1

        if (matches.Count <> 0) then
            max_page <- (matches.Item(0).Groups.Item(1).Value |> int)
        

        showLog(System.String.Format("\tPages: {0}  ",max_page))

        let filename = u + "\\" + currentnovel.Replace(" ", "_").Replace("\\","_").Replace("/", "_").Replace("*", "_").Replace("?", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_").Replace(":", "_")  + ".txt"

        if (novelPage = -1) then
            let out = File.CreateText(filename)
            out.Write("") |> ignore
            out.Close() |> ignore
            File.AppendAllText(filename, "<BODY>")

        showLog(System.String.Format("\tFilename: {0} ",filename))

        for i in (match (novelPage <> -1) with | true -> novelPage | false -> 1) .. max_page do
            novelPage <- -1
            let req:WebRequest = WebRequest.Create(host + currentlink + "?p=" + i.ToString());
            req.Method <- "GET"

            let resp = new StreamReader(req.GetResponse().GetResponseStream())
            let respstr = resp.ReadToEnd();

            let matches_3 = Regex.Match(respstr, matching_text)
    
            let a:string = HttpUtility.HtmlDecode(matches_3.Groups.[1].Value.Replace("\t","").Replace("\r","").Replace("\n","").Replace("  "," ").Replace("<p>", "<br />").Replace("</p>",""));

            File.AppendAllText(filename, a)
            showLog(System.String.Format("\t\tComplete Page: {0} - Length = {1}",i,a.Length))
        File.AppendAllText(filename, "</BODY>")

[<EntryPoint>]
let main args =
    log4net.Config.XmlConfigurator.Configure() |> ignore

    let userList = new List<string>();

    if (args.Length <> 0) then
        for x in args do
            if (x.Contains("/u:")) then
                (x.Split(':').[1] |> string).Split('&') |> Seq.iter (fun x -> 
                                                                        if (not(userList.Contains(x))) then
                                                                            userList.Add(x)
                                                                    )
            else if (x.Contains("/t:")) then
                    x.Split(':').[1].Split('&') |> (fun str ->
                                                        resumeList.Add(str.[0], new List<string>([|str.[1]; str.[2]|]))
                                                    )


    for user in userList do
        getuser user
    0
