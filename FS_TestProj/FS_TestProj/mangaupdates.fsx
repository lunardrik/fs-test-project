

open System.Net
open System.IO
open System.Text
open System.Web
open System.Text.RegularExpressions
open System.Collections.Generic

let host = "http://www.mangaupdates.com/"
let filename = "manga_list_mangaupdates.txt"
let req:HttpWebRequest = WebRequest.Create(host + "series.html?perpage=100") :?> HttpWebRequest;
req.Method <- "GET"

//req.Proxy <- new System.Net.WebProxy("proxyf.fsoft-hcm.fpt.vn:8080", true, [||])
//
//req.UserAgent <- "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/534.15 (KHTML, like Gecko) Chrome/10.0.612.3 Safari/534.15"
let a:List<string> = new List<string>()
//
//req.ContentType <- "application/x-www-form-urlencoded";
//let postData = "Cart_ctl00_phlCenter_ctl00_calSearch_Callback_Param=all%&Cart_ctl00_phlCenter_ctl00_calSearch_Callback_Param=&Cart_ctl00_phlCenter_ctl00_calSearch_Callback_Param=&Cart_ctl00_phlCenter_ctl00_calSearch_Callback_Param=1"
//let byteArr = Encoding.UTF8.GetBytes(postData)
//let contentLength = (byteArr.Length |> int64)
//req.ContentLength <- contentLength
//req.Accept <- "*/*"
//req.Expect <- "100-continue"
//req.Headers.Add("Expect", "100-continue")

//req.Host <- "media.tuoitre.vn"
//let dataStream  = req.GetRequestStream()
//dataStream.Write(byteArr, 0, byteArr.Length)
//dataStream.Close() |> ignore

let resp = new StreamReader(req.GetResponse().GetResponseStream())
let respstr = resp.ReadToEnd()

//printf "%s" respstr

let m = Regex.Match(respstr, @"Pages \((\d+)\)")
let mutable max_page = 0

max_page <- (m.Groups.[1].Value |> int)


printf "%i\n" max_page

let out = File.CreateText(filename)
out.Write("") |> ignore
out.Close() |> ignore

for i in 0 .. max_page do
    let req:WebRequest = WebRequest.Create(host + "series.html?perpage=100&page=" + i.ToString());
    req.Method <- "GET"

    let resp = new StreamReader(req.GetResponse().GetResponseStream())
    let respstr = resp.ReadToEnd()

    let matches = Regex.Matches(respstr,@"<a href='http://www\.mangaupdates\.com/series\.html\?id=(\d+)' alt='Series Info'>([^\<\>]*)</a>")
    a.Clear() |> ignore


    for i in 0 .. (matches.Count - 1) do
//        let desreq:WebRequest = WebRequest.Create(host + matches_3.Item(i).Groups.Item(1).Value);
//        desreq.Method <- "GET"
//
//        let desresp = new StreamReader(desreq.GetResponse().GetResponseStream())
//        let desrespstr = desresp.ReadToEnd()
//
//        let m_author = Regex.Match(desrespstr, @"<td align=""right"" nowrap=""nowrap""><strong>Author\(s\):</strong></td>\s+<td>([^\<\>]*)</td>")
//        let m_description = Regex.Match(desrespstr, @"<p style=""width:570px; padding:5px;"">([^\<\>]*)</p>")
        a.Add(HttpUtility.HtmlDecode(matches.Item(i).Groups.Item(2).Value) + "\t"  + matches.Item(i).Groups.Item(1).Value + "")
    File.AppendAllLines(filename, a)
    printf "Complete Page: %i\n" i
    
