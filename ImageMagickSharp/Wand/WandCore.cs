﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{

	public interface IWandCore
	{
		/// <summary> Gets the handle of the wand. </summary>
		/// <value> The wand handle. </value>
		IntPtr Handle { get; }
		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		int CheckError(int status);
		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		bool CheckErrorBool(int status);
		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		bool CheckError(bool status);
	}


	public abstract class WandCore<T> : IWandCore where T : class,IWandCore, new()
	{

		#region [Wand Handle]
		/// <summary> Gets the handle of the wand. </summary>
		/// <value> The wand handle. </value>
		public IntPtr Handle { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.WandCore&lt;T&gt; class. </summary>
		public WandCore()
		{
		}

		/// <summary>
		/// Initializes a new instance of the WandCore class.
		/// </summary>
		/// <param name="handle"></param>
		public WandCore(IntPtr handle)
		{
			Handle = handle;
		}

		public static implicit operator WandCore<T>(IntPtr wand)
		{
			return (WandCore<T>)Activator.CreateInstance(typeof(WandCore<T>), wand);
		}

		public static implicit operator IntPtr(WandCore<T> wand)
		{
			return wand.Handle;
		}



		#endregion

		#region [Wand Check Error]

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public int CheckError(int status)
		{
			if (status == Constants.MagickFalse)
			{
				throw new WandException(this.Handle);
			}

			return status;
		}

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool CheckErrorBool(int status)
		{
			if (status == Constants.MagickFalse)
			{
				throw new WandException(this.Handle);
			}

			return true;
		}

		public bool CheckErrorBool(bool status)
		{
			if (status == false)
			{
				throw new WandException(this.Handle);
			}

			return status;
		}

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool CheckError(bool status)
		{
			if (status == false)
			{
				throw new WandException(this.Handle);
			}

			return status;
		}

		#endregion

	}
}
