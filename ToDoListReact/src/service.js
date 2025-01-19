import axios from 'axios';

const API_URL = "http://localhost:5179/items"; // הכתובת החדשה של ה-API עם הנתיב הנכון

const service = {
  async getTasks() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error("Error fetching tasks:", error);
      return [];
    }
  },

  async addTask(newTask) {
    try {
      const response = await axios.post(API_URL, { name: newTask, isComplete: false });
      return response.data;
    } catch (error) {
      console.error("Error adding task:", error);
    }
  },

  async setCompleted(id, isComplete) {
    try {
      const response = await axios.put(`${API_URL}/${id}`, { isComplete });
      return response.data;
    } catch (error) {
      console.error("Error updating task completion:", error);
    }
  },

  async deleteTask(id) {
    try {
      await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
      console.error("Error deleting task:", error);
    }
  }
};

export default service;
