using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NFTB.Contracts.Exceptions;

namespace NFTB.Logic.Validators
{
	public class EmailFormatValidator : NFTB.Contracts.Validators.IEmailFormatValidator
	{
		/// <summary>
		/// Indicates that this email does not already exist in the data store
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public void Validate(string email)
		{
			if (string.IsNullOrEmpty(email)) return;

			// Check for other people with this email
			var regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
			if (!regex.IsMatch(email)) { throw new EmailFormatException(); }
		}
	}
}
