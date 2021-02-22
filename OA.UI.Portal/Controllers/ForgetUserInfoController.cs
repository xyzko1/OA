using System;
using OA.IBLL;
using OA.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace OA.UI.Portal.Controllers
{
    public class ForgetUserInfoController : Controller
    {
        // GET: ForgetUserInfo
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInfo userInfo)
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
            var pageData = UserInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal && u.UName == userInfo.UName && u.Email == userInfo.Email, u => u.ID, true)
                .Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn, u.Email });
            if (pageData.Count() > 0)
            {
                MailMessage mailMsg = new MailMessage();//引用含.NET的类
                mailMsg.From = new MailAddress("1442676691@qq.com", "发件人xyz");//源地址
                mailMsg.To.Add(new MailAddress("931985617@qq.com", "徐育智"));//目标地址
                mailMsg.Subject = "邮件标题";
                mailMsg.Body = "邮件内容";
                //指定Smtp服务地址，发件人地址
                SmtpClient client = new SmtpClient("smtp.qq.com");//smtp.126.com   smtp.163.com  smtp.qq.com
                client.EnableSsl = true;
                client.UseDefaultCredentials = false; 
                client.Credentials = new NetworkCredential("1442676691@qq.com", "a132355610");
                client.Send(mailMsg);

                return Content("邮件发送成功!");
            }
            else
            {
                return Content("用户名与邮箱信息不匹配!");
            }
        }
    }
}