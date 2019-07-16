using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Interfaces;
using BorderControl.Exception;

namespace BorderControl.Model
{
    public class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id,int inputNumber)
        {
            this.Model = model;
            this.Id = id;
            this.InputNumber = inputNumber;
        }
        public int InputNumber { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage.ModelIsNulleOrEmpty);
                }
                this.model = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                this.id = value;
            }
        }
    }
}
