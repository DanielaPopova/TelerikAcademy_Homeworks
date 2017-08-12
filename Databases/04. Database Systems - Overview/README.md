## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?
	
	+ Hierarchical - data is organized in a tree structure (directories with their subdirectories/files)
	+ Network/graph - allows multiple records to be linked to the same owner file
	+ Relational - represented with tables
	+ Object-oriented - data is stored as objects
	
2.  Which are the main functions performed by a Relational Database Management System (RDBMS)?

	- adding, deleting, changing, seraching stored data in tables
	- handling relations between tables
	- supporting SQL
	
3.  Define what is "table" in database terms.

	A table is a colleciton of structured related data within a database. It consists of rows and columns,
	whereas rows are identified with a primary key (ususally a number, can be composite, always unique),
	and columns have name and type - number, string, date, image.

4.  Explain the difference between a primary and a foreign key.

	A foreign key is a set of one or more columns in a table that refers to the primary key in another table. 
	Primary keys cannot accept null values in contrast to foreign keys.

5.  Explain the different kinds of relationships between tables in relational databases.

	+ one-to-many (many-to-one)
		- A single record in the first table has many corresponding records in the second table
		- towns/countries
	+ many-to-many
    	- Records in the first table have many corresponding records in the second one and vice versa
		- additional table is created
		- students/courses
	+ one-to-one
	    - A single record in a table corresponds to a single record in the other table

6.  When is a certain database schema normalized?
  * What are the advantages of normalized databases?
	
	There are basic forms of normalization: 1st, 2nd, and 3rd normal form,
	which are progressive - to qualify for 3rd normal form a table must first satisfy the rules for 2nd normal form, and 2nd normal form must adhere to those for 1st.
	
	+ First Normal Form 
	   - Duplicative columns from the same table are removed. Separate tables for each group of related data are created and each row with a unique column or set of columns (the primary key) are idetified.
	+ Second Normal Form
		- Subsets of data that apply to multiple rows of a table are removed and placed in separate tables. Relationships between these new tables and their predecessors are created through the use of foreign keys.
	+ Third Normal Form
		- Columns that are not dependent upon the primary key are removed.
	
	Some advantages for database normalization are:
	+ minimize duplicate data
	+ minimize or avoid data modification issues
	+ simplify queries
  
7.  What are database integrity constraints and when are they used?

	Integrity constraints ensure integrity in the database tables and enforced rules that cannot be violated.
	+ primary key constraint - ensures that the primary key of a table has unique value for each table row
	+ unique key constraint - ensures that all values in a certain column (or a group of columns) are unique
	+ foreign key constraint - ensures that the value in given column is a key from another table
	+ check constraint - ensures that values in a certain column meet some predefined condition

8.  Point out the pros and cons of using indexes in a database.

	Indicies are used to speed up the search of value in a column (or group of columns).
	They speed up a select query, but slow down inserts, deletes and updates (dml).
	
9.  What's the main purpose of the SQL language?

	SQL (Structured Query Language) is used for manipulation of relational databases:
	+ create, alter, delete tables and other objects in the database
	+ search, insert, delete, modify data in tables

10.  What are transactions used for?
  * Give an example.
  
	Transactions are a sequence of database operations which are executed as a single unit: either all of them execute successfully or none of them is executed at all.
	All changes in a transaction are temporary unless COMMIT is executed, otherwise they can be cancelled with ROLLBACK.
	Example: bank transfer
  
11.  What is a NoSQL database?

	Instead of tables, NoSQL databases are document-oriented. This way, non-structured data (such as articles, photos, social media data, videos, or content within a blog post)
	can be stored in a single document that can be easily found but isn’t necessarily categorized into fields like a relational database does.
	NoSQL databases are more scalable and provide superior performance compared to relational databases.

12.  Explain the classical non-relational data models.

	+ Key-value model - the least complex NoSQL option, which stores data in a schema-less way that consists of indexed keys and values.
	Stored values can be any type of binary object (text, video, JSON document, etc.).
	*Examples:* Cassandra, Azure, LevelDB, and Riak.
	+ Document stores - typically store self-describing JSON, XML, and BSON documents. They are similar to key-value stores, but in this case, a value is a single document that stores all data related to a specific key.
	Popular fields in the document can be indexed to provide fast retrieval without knowing the key. Each document can have the same or a different structure.
	*Examples:* MongoDB, CouchDB.
	+ Column stores - or wide-column databases group columns of related data together. A query can retrieve related data in a single operation because only the columns associated with the query are retrieved.
	*Examples:* HBase, BigTable, HyperTable.
	+ Graph stores - uses graph structures to store, map, and query relationships. They provide index-free adjacency, so that adjacent elements are linked together without using an index.
	*Examples:* Polyglot, Neo4J, Cassandra.

13.  Give few examples of NoSQL databases and their pros and cons.

	+ MongoDB - A document-oriented database with JSON-like documents in dynamic schemas instead of relational tables. It’s open-source, with good customer service.
		- Speed: For simple queries, it gives good performance, as all the related data are in single document which eliminates the join operations.
		- Scalability: It is horizontally scalable i.e. you can reduce the workload by increasing the number of servers in your resource pool instead of relying on a stand alone resource.
		- Manageable: It is easy to use for both developers and administrators. This also gives the ability to shard database
		- Dynamic Schema: Its gives you the flexibility to evolve your data schema without modifying the existing data
	+ Redis - another open source NoSQL database which is mainly used because of its lightening speed. It is written in ANSI C language.
		- Data structures: Redis provides efficient data structures to an extend that it is sometimes called as data structure server. The keys stored in database can be hashes, lists, strings, sorted or unsorted sets.
		- Redis as Cache: You can use Redis as a cache by implementing keys with limited time to live to improve the performance.
		- Very fast: It is consider as one of the fastest NoSQL server as it works with the in-memory dataset.
	+ CouchDB - a document based NoSQL database. It stores data in form of JSON documents.
		- Schema-less: As a member of NoSQL family, it also have dynamic schema which makes it more flexible, having a form of JSON documents for storing data.
		- HTTP query: You can access your database documents using your web browser.
		- Conflict Resolution: It has automatic conflict detection which is useful while in a distributed database.
		- Easy Replication: Implementing replication is fairly straight forward.
	
