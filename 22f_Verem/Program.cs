using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22f_Verem
{
	internal class Program
	{
		class Verem<T>
		{
			class Elem<T>
			{
				public T tartalom;
				public Elem<T> alatta;

				public Elem()
				{
					tartalom = default;
					alatta = this;
				}
				public Elem(Elem<T> e, T tartalom)
				{
					this.tartalom = tartalom;
					this.alatta = e.alatta;
					e.alatta = this;
				}
				public void KövetkezőTörlése() => this.alatta = this.alatta.alatta;
			}

			Elem<T> fejelem;

			public Verem()
			{
				fejelem = new Elem<T>();
			}

			public void Push(T tartalom) => new Elem<T>(fejelem, tartalom);
			public T Peek()
			{
				if (Empty())
					throw new IndexOutOfRangeException();
				return fejelem.alatta.tartalom;
			}
			public T Pop()
			{
				T result = Peek();
				fejelem.KövetkezőTörlése();
				return result;
			}
			public bool Empty() => fejelem.alatta == fejelem;

		}
		static void Main(string[] args)
		{
			Verem<int> v = new Verem<int>();

			v.Push(5);
			v.Push(2);
			v.Push(8);
			v.Push(9);


		}
	}
}
