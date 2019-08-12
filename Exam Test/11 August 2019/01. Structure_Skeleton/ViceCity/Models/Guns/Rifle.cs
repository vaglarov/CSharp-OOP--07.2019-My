using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name) 
            : base(name, 50, 500)
        {
        }

        public override int Fire()
        {
            if (!this.CanFire)
            {
                this.Reload();

            }

            if (this.BulletsPerBarrel < 5)
            {
                return 0;
            }

            this.BulletsPerBarrel -= 5;

            return 5;
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
