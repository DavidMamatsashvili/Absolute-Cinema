import SearchedMovie from "./searched-movie";

const SearchResult = ({ filteredMovies, search, onSearchChange, onClear, handleSearchDisplay }) => {
    const firstFive = filteredMovies.slice(0, 5)
    return (
        <div className="search-results">
            <div className="mobile-search-header">
                <div className="mobile-input">
                    <input type="text" id="mobile-search-input" value={search} onChange={onSearchChange} placeholder="ძებნა" />
                    <img src={search ? "images/close_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png" : "images/search_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png"} className="search-logo" onClick={onClear} alt="" />
                </div>
                <p className="close-search" onClick={handleSearchDisplay}>დახურვა</p>
            </div>
            <div className="results">
                {firstFive.map(movie => <SearchedMovie movie={movie} key={movie.name + "-" + movie.id} />)}
                {filteredMovies.length > 5 && <button className="show-all">ყველა</button>}
            </div>
        </div>
    )
}

export default SearchResult;