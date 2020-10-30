using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class BaseController : Controller
    {
        public IMapper Mapper
        {
            get
            {
                var _mapper = HttpContext.Items["Mapper"] as IMapper;
                return _mapper;
            }
        }

    }
}