﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandevouWpfClient.Models
{
    public static class ResultHandler
    {
        public static void Exception(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        public static void Message(String message)
        {
            MessageBox.Show(message);
        }
    }
}