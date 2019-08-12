using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name)
            : base(name, 10, 100)
        {
        }

        public override int Fire()
        {
            if (!this.CanFire)
            {
                this.Reload();

            }

            if (this.BulletsPerBarrel == 0)
            {
                return 0;
            }

            this.BulletsPerBarrel -= 1;

            return 1;
        }

        private void Reload()
        {
            if (this.TotalBullets < this.capacity)
            {
                this.BulletsPerBarrel = this.TotalBullets;
                this.TotalBullets = 0;
                return;
            }

            this.TotalBullets -= this.capacity;
            this.BulletsPerBarrel = this.capacity;
        }

    }
}
