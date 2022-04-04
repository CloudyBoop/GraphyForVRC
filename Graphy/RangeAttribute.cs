/* ---------------------------------------
 * Author:          Martin Pane (martintayx@gmail.com) (@tayx94)
 * Contributors:    https://github.com/Tayx94/graphy/graphs/contributors
 * Project:         Graphy - Ultimate Stats Monitor
 * Date:            15-Dec-17
 * Studio:          Tayx
 *
 * Git repo:        https://github.com/Tayx94/graphy
 *
 * This project is released under the MIT license.
 * Attribution is not required, but it is always welcomed!
 * -------------------------------------*/

using System;

namespace Tayx.Graphy
{
    internal class RangeAttribute : Attribute
    {
        private int v1;
        private int v2;

        public RangeAttribute(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}