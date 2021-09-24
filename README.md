## Summary
A system that outputs sorted datasets from wildcard character-delimited input files, and appends a single data record to the same files.


### Constraints
1. The delimiting character shall not appear in the data values.
2. All dates shall be outputted in _M/D/YYYY_ format.
3. The system shall not require a persistent datastore.
4. All data records shall consist of the following five (5) fields:

	`FirstName`
	`LastName`
	`Email`
	`FavoriteColor`
	`DateOfBirth`

### Technical Criteria
1. A command-line app in any language shall output three (3) different dataset views to the screen.
2. A standalone REST API in any language shall output JSON data from four (4) endpoints.


### Acceptance Criteria

 #### Command-Line App
1. The app shall output a dataset sorted first by `FavoriteColor` ascending, then sorted by `LastName` ascending.
2. The app shall output a dataset sorted by `DateOfBirth` ascending.
3. The app shall output a dataset sorted by `LastName` descending.

#### REST API
1. The app shall append a single record to an existing _pipe-delimited_ file dataset.
2. The app shall append a single record to an existing _comma-delimited_ file dataset.
3. The app shall append a single record to an existing _space-delimited_ file dataset.
4. The app shall output a dataset sorted by `FavoriteColor` ascending.
5. The app shall output a dataset sorted by `DateOfBirth` ascending.
6. The app shall output a dataset sorted by `LastName` ascending.
