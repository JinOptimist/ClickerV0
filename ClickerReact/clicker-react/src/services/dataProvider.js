import axios from 'axios'

function dataProvider() {

    const baseUrl = 'https://localhost:7159/api/';

    // const getLevelDetails = async (level) => await
    //     fetch(baseUrl + 'level/getDetail?level=' + level)
    //         .then(response => {
    //             return response.json()
    //         });
    const getLevelDetails = (level) => axios
        .get(baseUrl + 'level/getDetail?level=' + level)
        .then(response => {
            console.log(response);
            return response.data;
        });

    return {
        getLevelDetails
    };
}

export default dataProvider;
