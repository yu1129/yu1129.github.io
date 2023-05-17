// export default{
//     props: {
//         Name: {
//             type: String,
//             default: 'CHU'
//         }
//     },
//     template: '<h1>Hello world {{Name}}</h1>'
// }

export default{
    props:{
        Name:{
            type: String,
            required: true
        },
        Age:{
            type: Number,
            required: true
        }
    },
    template: '<h1>{{Name}} {{Age}}</h1>'
}