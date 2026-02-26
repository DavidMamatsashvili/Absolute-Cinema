const SearchedMovie = ({ movie }) => {
    return (
        <div className="searched-movie">
            {/* <img src={movie.image} alt="" className="searched-movie-image" /> */}
            <p className="searched-movie-image">{movie.id}</p>
            <p className="searched-movie-title">{movie.name}</p>
        </div>
    )
}

export default SearchedMovie;