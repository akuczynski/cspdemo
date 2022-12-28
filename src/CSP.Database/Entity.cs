using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.ModuleContracts.Database
{
 
	/// <inheritdoc cref="IEntity{TKey}" />
	[Serializable]
	public abstract class Entity 
	{
		/// <inheritdoc/>
		public virtual long Id { get; protected set; }

		protected Entity()
		{

		}

		protected Entity(long id)
		{
			Id = id;
		} 
		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[ENTITY: {GetType().Name}] Id = {Id}";
		}
	}
}
