import { useMemo, useState } from "react";
import SearchResult from "./search-result";


const Header = () => {
    const [search, setSearch] = useState('');
    const [openSearch, setOpenSearch] = useState(true);

    const movies = [
        { name: "cvjdkf", id: 1 },
        { name: "jkvsds", id: 2 },
        { name: "caadscvfvgfvs", id: 3 },
        { name: "mjnhcbhfv", id: 4 },
        { name: "casdcscf", id: 5 },
        { name: "casccfvgvg", id: 6 }
    ];
    const filteredMovies = useMemo(() => {
        return movies.filter(movie => movie.name.includes(search));
    }, [movies, search])

    
    const handleSearch = (e) => {
        const newSearch = e.target.value;
        setSearch(newSearch);
    }

    const handleClear = () => {
        setSearch('');
    }

    const handleSearchDisplay = () => {
        setOpenSearch(!openSearch);
    }

    return (
        <header>
            <div className="for-center">
                <img src="images/logo.png" alt="" className="header-logo" />
                <div className="search-user">
                    <div className="mobile-search" onClick={handleSearchDisplay}>
                        <img src="images/search_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png" className="search-logo" alt="" />
                    </div>
                    <div className="desktop-search">
                        <input type="text" id="desktop-search-input" value={search} onChange={handleSearch} onFocus={() => setOpenSearch(true)} onBlur={() => setOpenSearch(true)} placeholder="ძებნა" />
                        <img src={search ? "images/close_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png" : "images/search_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png"} className="search-logo" onClick={handleClear} alt="" />
                    </div>
                    <div className="user">
                        <img src="images/person_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png" className="user-logo" alt="" />
                        <p className="user-text">შესვლა</p>
                    </div>
                </div>
            </div>
            {openSearch && <SearchResult filteredMovies={filteredMovies} search={search} onSearchChange={handleSearch} onClear={handleClear} handleSearchDisplay={handleSearchDisplay} />}
        </header>
    )
}

export default Header;