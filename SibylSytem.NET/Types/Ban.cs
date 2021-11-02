/*
    SibylSystem.NET - .NET library for the Sibyl System antispam API for telegram

    Copyright (C) 2021 Sayan Biswas

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace SibylSystem.NET.Types
{
    public class Ban
    {
        public long? UserId { get; set; }
        public bool? Banned { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public string BanSourceUrl { get; set; }
        public long? BannedBy { get; set; }
        public long? CrimeCoefficient { get; set; }
        public string Date { get; set; }
        public string[] BanFlags { get; set; }
    }
}
