import DateFilter from "../Date-filter/Date-filter"
import MobileDropdownFilter from "../Mobile-dropdown-filter/Mobile-dropdown-filter";

const Filtering = () => {
    return (
        <div className="filtering">
            <DateFilter />
            <div className="other-filtering">
                <div className="theater-filter">
                    <p>theater</p>
                    <MobileDropdownFilter title={"Theater"}/>
                </div>
                <div className="session-filter">
                    <p>session</p>
                </div>
                <div className="language-filter">
                    <p>language</p>
                </div>
                <div className="subtitles-filter">
                    <p>subtitles</p>
                </div>
                <div className="genres-filter">
                    <p>genres</p>
                </div>
                <div className="formats-filter">
                    <p>formats</p>
                </div>
            </div>
        </div>
    )
}

export default Filtering;