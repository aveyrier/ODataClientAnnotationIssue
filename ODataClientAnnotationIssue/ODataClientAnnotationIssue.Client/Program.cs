using ODataClientAnnotationIssue.Client.ODataClientAnnotationIssue.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClientAnnotationIssue.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Default.Container container = new Default.Container(new Uri("http://localhost:64944"));

            container.SendingRequest2 += (sender, e) => e.RequestMessage.SetHeader("Prefer", "odata.include-annotations=\"*\"");

            IEnumerable<Product> products = container.Products.ToList();

            bool annotation;

            if (container.TryGetAnnotation<bool>(products.First(), "foo.bar", out annotation))
            {
                Console.WriteLine("@foo.bar value is " + annotation.ToString());
            }

            if (container.TryGetAnnotation<Func<string>, bool>(() => products.First().Name, "foo.bar", out annotation))
            {
                Console.WriteLine("Name@foo.bar value is " + annotation.ToString());
            }

            Console.Read();
        }
    }
}
