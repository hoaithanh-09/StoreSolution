using System;

namespace Store.ViewModels.Common
{
	public class ObjectPropertyAttribute: Attribute
	{
		private string _name;

		public ObjectPropertyAttribute(string name)
		{
			_name = name;
		}

		public override string ToString() => _name;
	}
}
