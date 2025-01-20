import { configureStore } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage"; // localStorage için
import cartReducer from "./cartSlice";
import authReducer from "./slices/authSlice"; // Auth için reducer'ınız (varsa)

// Persist ayarları
const persistConfig = {
  key: "root",
  storage,
  whitelist: ["auth"], // Sadece auth reducer'ını persist edeceğiz
};

// Auth reducer'ı persist etmek
const persistedReducer = persistReducer(persistConfig, authReducer);

const store = configureStore({
  reducer: {
    cart: cartReducer,
    auth: persistedReducer, // Auth reducer'ını persist edilen reducer ile değiştiriyoruz
  },
});

// `persistor` öğesini export etmeyi unutmayın
const persistor = persistStore(store);

export { store, persistor };

// Redux store'un türlerini export edin
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
