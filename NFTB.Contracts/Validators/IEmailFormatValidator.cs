using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFTB.Contracts.Validators
{
	public interface IEmailFormatValidator
	{
		/// <summary>
		/// Indicates that this email does not already exist in the data store
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		void Validate(string email);
	}
}
