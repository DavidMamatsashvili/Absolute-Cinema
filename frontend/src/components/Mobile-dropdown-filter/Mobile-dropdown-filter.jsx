import { useState } from "react";

const MobileDropdownFilter = ({ title, }) => {
    const [show, setShow] = useState(true);


    const handleShow = (e) => {
        const name = e.target.className;
        if (name === "mobile-dropdown-filter" || name === "mobile-filter-close" || name === "mobile-filter-btn") setShow(!show);
    }
    return (
        <div className="mobile-dropdown-filter" style={{ display: show ? "flex" : "none" }} onClick={handleShow}>
            <div className="mobile-filter-box">
                <div className="mobile-filter-header">
                    <p className="mobile-filter-title">{title}</p>
                    <div className="mobile-filter-close">
                        {/* <img src="" alt="" /> */}
                    </div>
                </div>
                <div className="mobile-filter-categories" style={{ maxHeight: "407px", overflow: "auto" }}>
                    <label className="category"
                        style={{
                            backgroundColor: "rgb(41, 44, 74)",
                            width: "100%",
                            padding: "20px",
                            borderRadius: "10px",
                            marginBottom: "12px",
                            display: "flex",
                            justifyContent: "space-between"
                        }}>
                        <div style={{display: "flex", alignItems: "center", gap: ".75rem"}}>
                            {/* <img src="" alt="" /> */}
                            {/* <div style={{width: "40px", height: "30px", backgroundColor: "black"}}></div> */}
                            <p>Cavea Tbilisi Mali</p>
                        </div>
                        <input type="checkbox" name={title} value={"Cavea Tbilisi Mali"}  
                        style={{
                            appearance: "none",
                            width: "20px",
                            height: "20px",
                            // accentColor: "rgb(23 180 0)",
                            borderRadius: ".375rem",
                            border: "1px solid rgb(125 127 135)"
                        }}/>
                    </label>
                    {/* <p style={{backgroundColor: "rgb(41, 44, 74)", width: "100%", padding: "20px", borderRadius: "10px", marginBottom: "12px"}}>cdfcsfd</p>
                    <p style={{backgroundColor: "rgb(41, 44, 74)", width: "100%", padding: "20px", borderRadius: "10px", marginBottom: "12px"}}>cdfcsfd</p> 
                    <p style={{backgroundColor: "rgb(41, 44, 74)", width: "100%", padding: "20px", borderRadius: "10px", marginBottom: "12px"}}>cdfcsfd</p>
                    <p style={{backgroundColor: "rgb(41, 44, 74)", width: "100%", padding: "20px", borderRadius: "10px", marginBottom: "12px"}}>cdfcsfd</p>
                    <p style={{backgroundColor: "rgb(41, 44, 74)", width: "100%", padding: "20px", borderRadius: "10px", marginBottom: "12px"}}>cdfcsfd</p> */}
                    {/* {categories.map(category => )} */}
                </div>
                <div className="mobile-filter-footer">
                    <button className="mobile-filter-clear">Clear</button>
                    <button className="mobile-filter-btn">Filter</button>
                </div>
            </div>
        </div>
    )
}

export default MobileDropdownFilter;