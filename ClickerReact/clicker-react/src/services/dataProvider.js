function dataProvider() {

    const baseUrl = 'https://localhost:7159/api/';

    const getLevelDetails = async (level) => await
        fetch(baseUrl + 'level/getDetail?level=' + level)
            .then(response => {
                return response.json()
            });

    return {
        getLevelDetails
    };
}

export default dataProvider;
