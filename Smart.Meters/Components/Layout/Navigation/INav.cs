using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Meters.Components.Layout
{
    public interface INav
    {
        RenderFragment ChildContent { get; }
        //bool Active { get; }
    }
}
