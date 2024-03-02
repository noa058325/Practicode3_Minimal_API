import axios from 'axios';
axios.defaults.baseURL ="http://localhost:5179";

axios.interceptors.response.use(
  response => response, 
  error => {
    console.error('My Response error:', error.response.status, error.response.data);
    return Promise.reject(error); 
    }
);


export default {
  getTasks: async () => {
    const result = await axios.get(`/todos`)    
    return result.data;
  },

  addTask: async(id,name)=>{
    var add={id:id,name:name,isComplete:false};
    await axios.post(`/todo`,add)
    return {add};
  },

  setCompleted: async(id, isComplete)=>{
    console.log('setCompleted', {id, isComplete});
    var new_={id:id,name:"",isComplete:isComplete};
    await axios.put(`/todo/${id}`,new_);
    return {new_};
  },

  deleteTask:async(id)=>{
    console.log('deleteTask')
    await axios.delete(`/todo/${id}`);
  }
};
