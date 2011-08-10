
open System.Net
open System.IO
open System.Text
open System.Web
open System.Text.RegularExpressions
open System.Collections.Generic

let host = "http://manga.animea.net/"
let req:HttpWebRequest = WebRequest.Create(host + "browse.html") :?> HttpWebRequest;
req.Method <- "GET"

let a:List<string> = new List<string>()

let resp = new StreamReader(req.GetResponse().GetResponseStream())
let respstr = resp.ReadToEnd()

let matches = Regex.Matches(respstr, @"<a href=""\?page=(\d+)"">\d+</a>")
let mutable max_page = 0

for i in 0 .. (matches.Count - 1) do
    if matches.Item(i).Groups.Item(1).Value |> int > max_page then
        max_page <- (matches.Item(i).Groups.Item(1).Value |> int)


printf "%i\n" max_page

let out = File.CreateText("manga_list.txt")
out.Write("") |> ignore
out.Close() |> ignore

for i in 0 .. max_page do
    let req:WebRequest = WebRequest.Create(host + "browse.html?page=" + i.ToString());
    req.Method <- "GET"

    let resp = new StreamReader(req.GetResponse().GetResponseStream())
    let respstr = resp.ReadToEnd()

    let matches_3 = Regex.Matches(respstr,@"<tr><td><a href=""\/([^\<\>]*\.html)"" class=""i?n?complete_manga"" title=""\""?([^\<\>]*) manga"">([^\<\>]*)</a></td><td class=""c"">(\d+)</td></tr>")
    a.Clear() |> ignore


    for i in 0 .. (matches_3.Count - 1) do
        let desreq:WebRequest = WebRequest.Create(host + matches_3.Item(i).Groups.Item(1).Value);
        desreq.Method <- "GET"

        let desresp = new StreamReader(desreq.GetResponse().GetResponseStream())
        let desrespstr = desresp.ReadToEnd()

        let m_author = Regex.Match(desrespstr, @"<td align=""right"" nowrap=""nowrap""><strong>Author\(s\):</strong></td>\s+<td>([^\<\>]*)</td>")
        let m_description = Regex.Match(desrespstr, @"<p style=""width:570px; padding:5px;"">([^\<\>]*)</p>")
        a.Add(HttpUtility.HtmlDecode(matches_3.Item(i).Groups.Item(3).Value) + "("  + matches_3.Item(i).Groups.Item(4).Value + ") - " + m_author.Groups.Item(1).Value + "\n\t" + m_description.Groups.Item(1).Value.Replace("\n\n","\n").Replace("\n","\n\t") + "\n")
    File.AppendAllLines("manga_list.txt", a)
    printf "Complete Page: %i\n" i
    