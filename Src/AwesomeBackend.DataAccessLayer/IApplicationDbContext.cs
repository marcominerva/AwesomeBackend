using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.DataAccessLayer
{
	public interface IApplicationDbContext
	{
		// Recupera le informazioni da una tabella generica.
		IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class;

		// Metodi generici per l'inserimento dei dati.
		void Insert<T>(T entity) where T : class;

		// Metodi generici per l'aggiornamento dei dati.
		void Update<T>(T entity) where T : class;

		// Metodi generici per la cancellazione dei dati.
		void Delete<T>(T entity) where T : class;

		// Effettua il salvataggio delle modifiche.
		Task SaveAsync();
	}
}
