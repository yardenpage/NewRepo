using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.View;
using ATP2016Project.Model;

namespace ATP2016Project.Controller
{
    public class MyController : IController
    {
        public Dictionary<string, ICommand> getCommands()
        {
            throw new NotImplementedException();
        }

        public void Output(string output)
        {
            throw new NotImplementedException();
        }

        public void SetModel(IModel model)
        {
            throw new NotImplementedException();
        }

        public void SetView(IView view)
        {
            throw new NotImplementedException();
        }
    }
}
