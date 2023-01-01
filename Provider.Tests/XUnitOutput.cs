using PactNet.Infrastructure.Outputters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Provider.Tests
{
    public class XUnitOutput : IOutput
    {
        private readonly ITestOutputHelper output;

        public XUnitOutput(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string line)
        {
            this.output.WriteLine(line);
        }
    }
}
