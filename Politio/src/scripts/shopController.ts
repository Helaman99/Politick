import Axios from 'axios'

let avatarsList = Array<string>
Axios.get('https://localhost:7060/Player/GetAvatars')
                    .then((response) => {
                        avatarsList(response.data)
                    })
                    .catch((err) => {
                        console.log(err)
                    })

export default { avatarsList }