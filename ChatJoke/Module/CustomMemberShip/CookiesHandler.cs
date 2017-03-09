using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatJoke.Module.CustomMemberShip
{
    public class CookiesHandler
    {
        public string CName {get; private set; }
        private readonly HttpResponseBase _response;
        private readonly HttpRequestBase _request;

        public CookiesHandler()
        {
            var http = new HttpContextWrapper(HttpContext.Current);
            _response = http.Response;
            _request = http.Request;
        }
        /// <summary>
        /// Метод определения Кука, и множества его значений
        /// Если праметр httpOnly или Secur не заданны то Кука создаётся без параметров безопасности, т.е. публичной
        /// </summary>
        /// <param name="val">Набор значений кука </param>
        /// <param name="minutes"> Срок жизни кука </param>
        /// <param name="httpOnly"> Взаимо исключающий прараметр уcтанавливает безопасность кука только HTTP-ONLY </param>
        /// <param name="Secur"> Взаимо исключающий прараметр устанавливает максимальный уровень безопасности кука (http-only и и необходимость протокола https) </param>
        public void Set(IEnumerable<CookiesModel> val, int minutes, bool httpOnly = false, bool secur = false)
        {
            if (_request.Cookies[CName] != null) return;

            var newCookie = new HttpCookie(CName);

            foreach (var c in val) newCookie.Values[c.Name] = c.Val;

            newCookie.Expires = DateTime.Now.AddMinutes(minutes);

            if (httpOnly && !secur) newCookie.HttpOnly = true;
            if (!httpOnly && secur) { newCookie.HttpOnly = true; newCookie.Secure = true; }

            _response.Cookies.Add(newCookie);
        }

        /// <summary>
        /// Метод определения Кука,
        /// Если праметр httpOnly или Secur не заданны то Кука создаётся без параметров безопасности, т.е. публичной
        /// </summary>
        /// <param name="val"> Значение </param>
        /// <param name="expir"> Срок жизни кука </param>
        /// <param name="httpOnly"> Взаимо исключающий прараметр уcтанавливает безопасность кука только HTTP-ONLY </param>
        /// <param name="secur"> Взаимо исключающий прараметр устанавливает максимальный уровень безопасности кука (http-only и необходимость протокола https) </param>
        public void Set(string val, DateTime expir, bool httpOnly = false, bool secur = false)
        {
            if (_request.Cookies[CName] != null) return;

            var newCookie = new HttpCookie(CName) { Value = val, Expires = expir };

            if (httpOnly && !secur) newCookie.HttpOnly = true;
            if (!httpOnly && secur) { newCookie.HttpOnly = true; newCookie.Secure = true; }

            _response.Cookies.Add(newCookie);
        }

        /// <summary>
        /// Метод возвращает текущую куку)))
        /// </summary>
        /// <returns>Возвращает тип HttpCookie</returns>
        public HttpCookie Get()
        {
            return _request.Cookies[CName];
        }

        /// <summary>
        /// Метод возвращает Все куки
        /// </summary>
        /// <returns>Возвращает тип HttpCookieCollection</returns>
        public HttpCookieCollection GetAll()
        {
            return _request.Cookies;
        }

        /// <summary>
        /// Универсальный метод удаления куков на стороне клиента, с взаимо  исключающими параметрами.
        /// </summary>
        /// <param name="cName">набо имён куков (не обязателен)</param>
        /// <param name="all">признок говорящий о том нужно ли удалять все куки текущего сайта на стороне клиента (не обязателен)</param>
        public void Remove(IEnumerable<string>cName=null, bool all = false)
        {

            var exp = DateTime.Now.AddDays(-1d);

            if (cName == null && !all)
            {
                var c = _request.Cookies[CName];
                if (c != null)
                {
                    var co = new HttpCookie(CName) { Expires = exp };
                    _response.Cookies.Set(co);
                }

                return;
            }

            var cx = !all ?
                from co in cName
                let x = _request.Cookies[co]
                where x != null
                select new HttpCookie(co) { Expires =  exp }
                :
                from string co in _request.Cookies
                select new HttpCookie(co) { Expires = exp };

                foreach (var co in cx)
                {
                    _response.Cookies.Set(co);
                }
        }

    }
}