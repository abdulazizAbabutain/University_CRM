using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class AddCollageCollocationCommand : IRequest
    {
        public List<AddCollageCommand> Collages { get; set; }
    }
}
