using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class funcionariosController : ApiController
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        public List<Funcionario> Get()
        {
            return funcionarios;
        }
    }
}
