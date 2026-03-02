import {useEffect, useMemo, useRef, useState} from "react";
import SearchResult from "../Search-result/Search-result.jsx";
import './Header.css'


const Header = () => {
    const [search, setSearch] = useState('');
    const [openSearch, setOpenSearch] = useState(false);

    const movies = [
        { name: "Theater Movie", id: 1 },
        { name: "OneDome", id: 2 },
        { name: "TroubleShoot", id: 3 },
        { name: "BigBan", id: 4 },
        { name: "Theory Mystery", id: 5 },
        { name: "Lirika", id: 6 }
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

    const searchRef = useRef();

    useEffect(() => {
        function handleClickOutside(event) {
            if (searchRef.current && !searchRef.current.contains(event.target)) {
                setOpenSearch(false);
            }
        }

        document.addEventListener("mousedown", handleClickOutside);
        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, []);

    return (
        <header className='flex w-full items-center justify-between py-6'>
            <div className="for-center">
                <img src="images/logo.png" alt="" className="header-logo" />
                <div className="search-user">
                    <div className="mobile-search" onClick={handleSearchDisplay}>
                        <img src="images/search_24dp_E3E3E3_FILL0_wght400_GRAD0_opsz24.png" className="search-logo" alt="" />
                    </div>
                    <div ref={searchRef} className="desktop-search">
                        <input type="text" id="desktop-search-input" value={search} onChange={handleSearch} onFocus={() => setOpenSearch(!openSearch)} onBlur={() => setOpenSearch(!openSearch)} placeholder="ძებნა" />
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